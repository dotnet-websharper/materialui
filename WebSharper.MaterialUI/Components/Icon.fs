namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

module Element = WebSharper.React.Obsolete.Element

[<AutoOpen>]
[<JavaScript>]
module Icon =
    
    [<Inline "MaterialUI.Icon">]
    let internal Class = X<ReactClass>

    type Icon(name : string) =
        inherit Component(Class, [ Element.Text name ])

        member val Properties =
            Generic.List [
                "className" => "material-icons"
            ]
