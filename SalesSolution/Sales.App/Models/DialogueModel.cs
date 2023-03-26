using Sales.APP.Enums;
using System.Reflection;

namespace Sales.APP.Models
{
    public class DialogueModel<T> where T : new()
    {
        public T ModelDTO;
        public string ActionType;
        public bool IsOpen;

        public DialogueModel(T modelDTO)
        {
            ModelDTO = modelDTO;
            ActionType = FormActionType.Add;
            IsOpen = false;
        }

        public DialogueModel(T modelDTO, string actionType, bool isOpen)
        {
            ModelDTO = modelDTO;
            ActionType = actionType;
            IsOpen = isOpen;
        }

        public bool IsAdd()
        {
            return ActionType == FormActionType.Add;
        }

        public bool IsEdit()
        {
            return ActionType == FormActionType.Edit;
        }

        public DialogueModel<T> AddDialogue()
        {
            ActionType = FormActionType.Add;
            return this;
        }

        public DialogueModel<T> EditDialogue()
        {
            ActionType = FormActionType.Edit;
            return this;
        }

        public DialogueModel<T> Open()
        {
            IsOpen = true;
            return this;
        }

        public DialogueModel<T> Close()
        {
            IsOpen = false;
            return this;
        }

        public DialogueModel<T> Clear()
        {
            ModelDTO = new T();
            return this;
        }

        public DialogueModel<T> Set(T orderDTO)
        {
            ModelDTO = orderDTO;
            return this;
        }

        public DialogueModel<T> Set(string modelPropertyName, object modelPropertyValue)
        {
            PropertyInfo property = this.ModelDTO.GetType().GetProperty(modelPropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            property.SetValue(this.ModelDTO, modelPropertyValue, null);

            return this;
        }
    }
}
