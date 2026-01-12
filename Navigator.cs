using Microsoft.AspNetCore.Components;

namespace CharacterSheet
{
    public class Navigator
    {
        private readonly NavigationManager _nav;

        public Navigator(NavigationManager nav)
        {
            _nav = nav;
        }

        public void ToCharacterSheet() => _nav.NavigateTo("/");
        public void ToManageCharacters() => _nav.NavigateTo("/manageCharacters");
    }
}
