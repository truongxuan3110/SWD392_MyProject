﻿using AutoMapper;
using OnlineLearning.DTOs;
using OnlineLearning.Entities;

namespace OnlineLearning.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, CourseDTOInList>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Question, QuestionAddUpdateDTO>().ReverseMap();
            CreateMap<Quiz, QuizDTO>().ReverseMap();
            CreateMap<Quiz, QuizAddUpdateDTO>().ReverseMap();
            CreateMap<Chapter, ChapterAddUpdateDTO>().ReverseMap();
        }
    }
}
