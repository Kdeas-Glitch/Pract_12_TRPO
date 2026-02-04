using Pract_12.Data;
using Pract_12.Service;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pract_12.ValidationRules
{
    class LoginValidation : ValidationRule
    {
        public StudentsService service { get; set; } = new();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text="";
            ObservableCollection < Student > st = service.Students;
            var input = (value ?? "").ToString().Trim();
            for (int i = 0; i < input.Count(); i++)
            {
                if (!Char.IsUpper(input[i]))
                {
                    text += Char.ToLower(input[i]);
                }
                else
                {
                    text += input[i];
                }
            }
            foreach(var a in st)
            {
                string text2 = "";
                for (int i = 0; i < a.Login.Count(); i++)
                {
                    if (!Char.IsUpper(a.Login[i]))
                    {
                        text2 += Char.ToLower(a.Login[i]);
                    }
                    else
                    {
                        text2 += a.Login[i];
                    }
                }
                if (text == text2)
                {
                    if (EditStudent.isEdit)
                    {
                        if (EditStudent.student.Login == text)
                        {
                            return ValidationResult.ValidResult;
                        }
                        else
                        {
                            return new ValidationResult(false, "Нужен оригинальный логин");
                        }
                    }
                    else
                        return new ValidationResult(false, "Нужен оригинальный логин");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
