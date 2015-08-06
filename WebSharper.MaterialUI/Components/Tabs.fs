namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

module Element = WebSharper.React.Element

[<AutoOpen>]
[<JavaScript>]
module Tabs =
    
    [<Inline "MaterialUI.Tabs">]
    let internal Class = X<ReactClass>

    type Tabs(tabs : Tab list) =
        inherit Component(Class, List.map (fun tab -> tab :> Element.GenericElement) tabs)

        member val Properties =
            Generic.List []
