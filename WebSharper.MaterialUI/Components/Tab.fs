namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module Tab =

    [<Inline "MaterialUI.Tab">]
    let internal Class = X<ReactClass>

    type Tab(label : string, children) =
        inherit Component(Class, children)

        member val Properties =
            Generic.List [
                "label" => label
            ]
