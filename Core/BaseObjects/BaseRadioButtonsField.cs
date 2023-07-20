using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.BaseObjects
{
    public abstract class BaseRadioButtonsField : BaseElement
    {
        public abstract void CheckOneOption<T>(T optionToCheck) where T : Enum;
    }
}
