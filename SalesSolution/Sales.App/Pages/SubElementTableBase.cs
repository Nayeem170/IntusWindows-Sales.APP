using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Enums;
using Sales.APP.Extentions;
using Sales.APP.Models;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class SubElementTableBase : ComponentBase
    {
        [Inject]
        public ISubElementService SubElementService { get; set; }
        [Inject]
        protected IMatToaster Toaster { get; set; }
        [Inject]
        protected IMatDialogService MatDialogService { get; set; }
        [Parameter]
        public WindowDTO Window { get; set; }
        [Parameter]
        public IEnumerable<SubElementDTO> SubElements { get; set; }
        [Parameter]
        public IEnumerable<ElementTypeDTO> ElementTypes { get; set; }
        [Parameter]
        public EventCallback<OrderDTO> OnChange { get; set; }

        protected IEnumerable<SubElementDTO> DisplayedSubElements { get; set; }
        public IEnumerable<SubElementDTO> OldSubElements { get; set; }
        public DialogueModel<SubElementDTO> SubElementDialogueModel { get; set; } = new DialogueModel<SubElementDTO>(new SubElementDTO());


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            OldSubElements = SubElements;
            DisplayedSubElements = SubElements;
            SubElementSearchText = string.Empty;
        }

        private bool shouldUpdate()
        {
            if (OldSubElements.Count() != SubElements.Count())
            {
                return true;
            }

            var bothEquals = OldSubElements.OrderBy(old => old.UId)
                    .ThenBy(old => old.UpdatedAt)
                .SequenceEqual(SubElements.OrderBy(current => current.UId)
                    .ThenBy(current => current.UpdatedAt));

            return !bothEquals;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (shouldUpdate())
            {
                OldSubElements = SubElements;
                DisplayedSubElements = SubElements;
                SubElementSearchText = string.Empty;
            }
        }

        private string _subElementSearchText;
        protected string SubElementSearchText
        {
            get => _subElementSearchText;
            set
            {
                _subElementSearchText = value;

                SubElementSearchTextOnUpdate(value);
            }
        }

        private void SubElementSearchTextOnUpdate(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                DisplayedSubElements = SubElements;
            }
            else
            {
                DisplayedSubElements = SubElements.Where(subElement =>
                    subElement.Element.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.Width.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.Height.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.Quantity.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.ElementTypeName.Contains(text, StringComparison.OrdinalIgnoreCase));
            }
        }

        protected void SortData(MatSortChangedEvent sort)
        {
            if (!(sort == null || sort.Direction == MatSortDirection.None || string.IsNullOrEmpty(sort.SortId)))
            {

                if (sort.SortId == "element" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.Element);
                }
                else if (sort.SortId == "element" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Element);
                }
                else if (sort.SortId == "width" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.Width);
                }
                else if (sort.SortId == "width" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Width);
                }
                else if (sort.SortId == "height" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.Height);
                }
                else if (sort.SortId == "height" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Height);
                }
                else if (sort.SortId == "quantity" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.Quantity);
                }
                else if (sort.SortId == "quantity" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Quantity);
                }
                else if (sort.SortId == "element-type" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.ElementTypeName);
                }
                else if (sort.SortId == "element-type" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.ElementTypeName);
                }
            }
        }

        public void OpenAddSubElementDialogue()
        {
            SubElementDialogueModel
                .Clear()
                .Set("WindowId", Window.UId)
                .Set("ElementTypeId", ElementTypes.FirstOrDefault()?.UId)
                .AddDialogue()
                .Open();
        }

        protected async Task OnSaveAsync()
        {
            var isSuccess = SubElementDialogueModel.IsAdd()
                          ? await SubElementService.AddSubElement(SubElementDialogueModel.ModelDTO)
                          : await SubElementService.EditSubElement(SubElementDialogueModel.ModelDTO);

            if (isSuccess)
            {
                await OnChange.InvokeAsync();
                SubElementDialogueModel.Close();
            }

            Action<string> toastAction = isSuccess
                ? (SubElementDialogueModel.IsAdd() ? Toaster.CreateSuccessful : Toaster.UpdateSuccessful)
                : (SubElementDialogueModel.IsAdd() ? Toaster.CreateFailed : Toaster.UpdateFailed);

            toastAction(DataModelType.Window);
        }

        public void OpenEditSubElementDialogue(SubElementDTO subElement)
        {
            SubElementDialogueModel
                .Set(subElement)
                .EditDialogue()
                .Open();
        }

        public async Task OpenDeleteSubElementPopupAsync(SubElementDTO subElementDTO)
        {
            var deleteThis = await MatDialogService.ConfirmAsync("Delete this sub element?");
            if (deleteThis)
            {
                var isDeleted = await SubElementService.DeleteSubElement(subElementDTO);

                await OnChange.InvokeAsync();

                Action<string> toastAction = isDeleted ? Toaster.DeleteSuccessful
                                                        : Toaster.DeleteFailed;
                toastAction(DataModelType.SubElement);
            }
        }

        protected void OnCancel()
        {
            SubElementDialogueModel.Close();
        }
    }
}
