namespace Core.BaseObjects.UI
{
    public abstract class BaseRadioButtonsField<T> : BaseObject where T : Enum
    {
        public abstract void CheckOneOption(T optionToCheck);
    }
}
