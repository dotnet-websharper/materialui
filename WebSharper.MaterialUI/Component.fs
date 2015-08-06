namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.React

[<AbstractClass>]
[<JavaScript>]
type Component(class', ?children) =
    inherit GenericElement()
        override this.Type = Choice2Of2 class'

    member val Children : GenericElement list = default' children []
