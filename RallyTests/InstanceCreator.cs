﻿using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    public class InstanceCreator
    {
        public Course CreateBeginnerCourse() 
        {
            Course course = new Course(LevelEnum.Beginner);
            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            return course;
        }

        public Course CreateExpertCourseWithTwoRightHandledExercises() 
        {
            Course course = new Course(LevelEnum.Expert);
            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(12, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(13, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(14, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(15, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(16, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(17, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(18, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(19, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(20, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            return course;  
        }

        public Course CreateExpertCourseWithThreeRightHandledExercises()
        {
            Course course = new Course(LevelEnum.Expert);
            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(12, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(13, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(14, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(15, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(16, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(17, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(18, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(19, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(20, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            return course;
        }

        public Course CreateChampionCourseWithThreeRightHandledExercises()
        {
            Course course = new Course(LevelEnum.Champion);
            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(12, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(13, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(14, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(15, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(16, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(17, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(18, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(19, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(20, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            return course;
        }

        public Course CreateChampionCourseWithFourRightHandledExercises()
        {
            Course course = new Course(LevelEnum.Champion);
            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(12, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(13, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(14, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(15, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(16, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(17, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(18, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(19, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(20, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            return course;
        }
    }
}