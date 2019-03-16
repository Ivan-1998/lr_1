using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace lab1.Models
{
    public class Lab1Data
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }

        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(Email)) validationResult.Append($"Поле Email не может быть пустым!");
            if (string.IsNullOrWhiteSpace(Phone)) validationResult.Append($"Поле телефон не может быть пустым!");
            if (Phone.Length != 11) validationResult.Append($"Телефон должен состоять из 11 символов");
            if (!string.IsNullOrEmpty(Name) && !char.IsUpper(Name.FirstOrDefault())) validationResult.Append($"Имя должно начинаться с большой буквы!");

            return validationResult;
        }

        public override string ToString()
        {
            return $"Данные с формы на сайте: Имя: {Name}, Email: {Email}, Телефон: {Phone}";
        }
    }
}