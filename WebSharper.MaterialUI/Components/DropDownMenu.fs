namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module DropDownMenu =
    
    [<Inline "MaterialUI.DropDownMenu">]
    let internal Class = X<ReactClass>

    type DropDownMenu(items : string list) =
        inherit Component(Class)

        member val Properties =
            let menuItems =
                items
                |> List.mapi (fun index item ->
                    New [
                        "payload" => string index
                        "text"    => item
                    ]
                )
            
            Generic.List [
                "menuItems" => List.toArray menuItems
                "autoWidth" => true
            ]
