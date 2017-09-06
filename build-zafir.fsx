#load "tools/includes.fsx"

open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.MaterialUI")
        .VersionFrom("WebSharper")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun x -> x.Net40)

let library =
    bt.WebSharper4.Library("WebSharper.MaterialUI")
        .SourcesFromProject()
        .References(fun ref ->
            [
                ref.NuGet("WebSharper.React").Latest(true).ForceFoundVersion().Reference()
            ])
        .Embed(
            [
                "material-ui.min.js"
            ])

let tests =
    bt.WebSharper4.BundleWebsite("WebSharper.MaterialUI.Tests")
        .SourcesFromProject()
        .References(fun ref -> 
            [
                ref.NuGet("WebSharper.React").Latest(true).Reference()
                ref.Project library
            ])

bt.Solution [
    library
    tests

    bt.NuGet.CreatePackage()
        .Configure(fun configuration ->
            { configuration with
                Title = Some "WebSharper.MaterialUI"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://bitbucket.org/intellifactory/websharper.materialui"
                Description = "WebSharper bindings for Material UI"
                Authors = [ "IntelliFactory" ]
                RequiresLicenseAcceptance = true })
        .Add(library)
]
|> bt.Dispatch
