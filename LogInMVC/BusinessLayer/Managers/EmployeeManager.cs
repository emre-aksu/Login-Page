﻿using BusinessLayer.Abstract;
using DataAccessLayer.InterFace;
using FluentValidation;
using ModelLayer.Dtos;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IValidator<LogInDto> _loginDtoValidator;
        public EmployeeManager(IEmployeeRepository empRepo, IValidator<LogInDto> loginDtoValidator)
        {
            _empRepo = empRepo;
            _loginDtoValidator = loginDtoValidator;
        }
        public async Task<Employee> LogIn(LogInDto dto)
        {
            #region SERVER SIDE VALIDATION

            var result = _loginDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                string errorMessages = string.Empty;

                foreach (var error in result.Errors)
                {
                    errorMessages += error.ErrorMessage + "<br/>";
                }
                //Validasyondan geçmediği durumda mvc ye bilgi verilecek
            }
            #endregion
            return await _empRepo.LogInAsync(dto.UserName, dto.Password);

        }
    }
}
