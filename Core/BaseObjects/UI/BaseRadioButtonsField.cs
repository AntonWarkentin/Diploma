namespace Core.BaseObjects.UI
{
    public abstract class BaseRadioButtonsField<T> : BaseElement where T : Enum
    {
        public abstract void CheckOneOption(T optionToCheck);
    }
}
