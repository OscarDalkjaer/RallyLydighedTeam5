﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class CourseVisualizer
    {
        

        public  List<(int, int, string, bool)> VisualiseCourse(Course course, HandlingPositionEnum startPosition)
        {
            List<Exercise> newList = course.AssignIndexNumbers();
            newList[0].LeftHandlet = true;

            if (startPosition == HandlingPositionEnum.Right)
            {
               newList[0].LeftHandlet = false;
            }


            foreach (Exercise x in newList)
            {
                if(x.IndexNumber > 0 && x.IndexNumber < newList.Count) 
                {
                    x.LeftHandlet = 
                        newList[(x.IndexNumber)].HandlingPosition != HandlingPositionEnum.ChangeOfPosition ?
                        newList[x.IndexNumber - 1].LeftHandlet : !newList[(x.IndexNumber - 1)].LeftHandlet;
                }                
            }


            List<(int, int, string, bool)> courseVisualized = new List<(int, int, string, bool)> ();
            courseVisualized.Add((newList[0].ExerciseId, newList[0].IndexNumber, newList[0].Name, newList[0].LeftHandlet));
            courseVisualized.AddRange(newList.Skip(1).Select(x => (x.ExerciseId, x.IndexNumber, x.Name, x.LeftHandlet)).ToList());
            return courseVisualized;
        }

        public List<(int, int, string, bool)> VisualiseRightHandledExercises(List<(int, int, string, bool)> visualisedCourse)
        {
            List<(int, int, string, bool)> exercisesWithRightHandling = visualisedCourse.Where(item => !item.Item4).ToList();
            return exercisesWithRightHandling;
        }


        
    }
}