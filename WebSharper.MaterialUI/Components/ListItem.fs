namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings
open WebSharper.React.Obsolete

[<AutoOpen>]
[<JavaScript>]
module ListItem =
    
    [<Inline "MaterialUI.ListItem">]
    let internal Class = X<ReactClass>

    type ListItem(?primaryText, ?secondaryText) =
        inherit Component(Class, [])

        member val Properties =
            Generic.List [
                "primaryText" => default' primaryText ""

                "secondaryText" => default' secondaryText ""
                "secondaryTextLines" => 2
            ]

        static member WithCheckbox state callback (listItem : ListItem) =
            let checkbox =
                Checkbox(state = state)
                |>! Check callback

            listItem.Properties.Add ("leftCheckbox", box (GenericElement.Transpile checkbox))
            listItem
