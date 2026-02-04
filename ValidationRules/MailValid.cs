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
    class MailValid : ValidationRule
    {
        public StudentsService service { get; set; } = new();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = "";
            ObservableCollection<Student> st = service.Students;
            var input = (value ?? "").ToString().Trim();
            if(!input.Contains("@"))
                return new ValidationResult(false, "Должен быть символ @");
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
            foreach (var a in st)
            {
                if (text == a.Email)
                {
                    if (EditStudent.isEdit)
                    {
                        if (EditStudent.student.Email == text)
                        {
                            return ValidationResult.ValidResult;
                        }
                    }
                    return new ValidationResult(false, "Такая почта уже есть");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
