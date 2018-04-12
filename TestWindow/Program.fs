// Learn more about F# at http://fsharp.org

open System

open OpenTK.Platform

[<EntryPoint>]
let main argv =
    use win = Factory.Default.CreateNativeWindow(100,100,800,600,"title",OpenTK.GameWindowFlags.Fullscreen,OpenTK.DisplayDevice.Default)

    win.WindowInfo |> printfn "window info: %A"
    win.Visible <- true

    while win.Exists do
        win.ProcessEvents()

    0
