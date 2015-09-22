namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type DropDownMenu(items : string list) =
    [<Inline "MaterialUI.DropDownMenu">]
    let class' () = X<ReactClass>

    let map items =
        items
        |> List.mapi (fun index item ->
            New [
                "payload" => string index
                "text"    => item
            ]
        )
        |> List.toArray
        
    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    "menuItems" => map items
                    "autoWidth" => true
                ])
