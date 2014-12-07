using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SzeregowanieProjekt2.Models.BasicModels;

namespace SzeregowanieProjekt2.Controllers.BusinessLogic
{
    public class LiuSort
    {
        Task blankTask;
        List<Task> tempTasksList;
        List<Task> resultList;
        List<Task> availableList;
        Dictionary<Task, int> L;
        Dictionary<int, int> processingTimeBackup; // <id,processingTime>

        public List<Task> SortedTasks(List<Task> unsortedTasks)
        {
            createBlank();
            tempTasksList = new List<Task>();
            resultList = new List<Task>();
            availableList = new List<Task>();
            tempTasksList = unsortedTasks;
            L = new Dictionary<Task, int>();
            backupProcessingTime();
            // end of init
            sort();

            recoverProcessingTime();
            return resultList; //rrrr
        }

        void backupProcessingTime()
        {
            processingTimeBackup = new Dictionary<int, int>();
            foreach (Task task in tempTasksList)
            {
                processingTimeBackup.Add(task.id, task.processingTime);
            }
        }

        void recoverProcessingTime()
        {
            foreach (Task task in resultList)
            {
               try{
                    task.processingTime = processingTimeBackup[task.id];
               }
               catch
               {
                   task.processingTime = 1;
               }
            }
        }

        void sort() {
            while (tempTasksList.Count > 0) 
            {
                availableList.RemoveRange(0, availableList.Count);

                if (tempTasksList.Count == 0)
                    return;
                else
                    tempTasksList.Sort((x, y) =>
                        x.deadline.CompareTo(y.deadline));

                foreach (Task task in tempTasksList)
                {
                    if (task.processingTime == 0)
                        L.Add(task, resultList.Count);
                }

                tempTasksList.RemoveAll(x => x.processingTime == 0);
                foreach (Task task in tempTasksList)
                {
                    if (task.release <= resultList.Count)
                        availableList.Add(task);
                }

                if(tempTasksList.Count != 0)
                    if (availableList.Count == 0)
                        resultList.Add(blankTask);
                    else
                    {
                        availableList.Sort((x, y) =>
                            x.deadline.CompareTo(y.deadline));

                        tempTasksList[tempTasksList.IndexOf(availableList[0])].processingTime--;
                        resultList.Add(availableList[0]);
                    }

            } 

        }

        public int returnLmax(List<Task> unsortedTasks)
        {
            if (unsortedTasks.Count > 0)
            {

                int theBiggestL = L[unsortedTasks[0]] - unsortedTasks[0].deadline;
                foreach (Task task in unsortedTasks)
                {
                    if (theBiggestL <= L[task] - task.deadline)
                        theBiggestL = L[task] - task.deadline;
                }

                return theBiggestL;
            }
            else
                return -1000;
        }

        void createBlank()
        {
            blankTask = new Task()
            {
                label = "",
                processingTime = 1,
                release = 0,
                color = new Color()
                {
                    red = 50,
                    green = 50,
                    blue = 50
                }
            };
        }

    }
}