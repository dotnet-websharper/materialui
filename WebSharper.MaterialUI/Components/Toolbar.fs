namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

module Element = WebSharper.React.Obsolete.Element

[<AutoOpen>]
[<JavaScript>]
module ToolbarGroup =
    
    type Position =
        | Left
        | Right

        override this.ToString () =
            match this with
            | Left  -> "left"
            | Right -> "right"

    [<Inline "MaterialUI.ToolbarGroup">]
    let internal Class = X<ReactClass>

    type ToolbarGroup(children, ?position : Position) =
        inherit Component(Class, children)

        member val Properties =
            Generic.List [
                match position with
                | Some position ->
                    yield "float" => string position
                | _ ->
                    ()
            ]

[<AutoOpen>]
[<JavaScript>]
module Toolbar =
    
    [<Inline "MaterialUI.Toolbar">]
    let internal Class = X<ReactClass>

    type Toolbar(groups : ToolbarGroup list) =
        inherit Component(Class, List.map (fun group -> group :> Element.GenericElement) groups)

        member val Properties =
            Generic.List []

[<AutoOpen>]
[<JavaScript>]
module ToolbarSeparator =
    
    [<Inline "MaterialUI.ToolbarSeparator">]
    let internal Class = X<ReactClass>

    type ToolbarSeparator() =
        inherit Component(Class)

        member val Properties =
            Generic.List []

[<AutoOpen>]
[<JavaScript>]
module ToolbarTitle =
    
    [<Inline "MaterialUI.ToolbarTitle">]
    let internal Class = X<ReactClass>

    type ToolbarTitle(text : string) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                "text" => text
            ]
