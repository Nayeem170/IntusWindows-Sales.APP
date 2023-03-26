using Microsoft.AspNetCore.Components;
using Sales.APP.Models;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class SubElementDialogBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ElementTypeDTO> ElementTypes { get; set; }
        [Parameter]
        public DialogueModel<SubElementDTO> SubElementDialogueModel { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        [Parameter]
        public EventCallback OnCancel { get; set; }
    }
}
