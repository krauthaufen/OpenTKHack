// Learn more about F# at http://fsharp.org

open System
open System.Threading
open OpenTK.Platform

[<EntryPoint>]
let main argv =

    use win = Factory.Default.CreateNativeWindow(100,100,800,600,"title",OpenTK.GameWindowFlags.Fullscreen,OpenTK.DisplayDevice.Default)

    win.WindowInfo |> printfn "window info: %A"
    win.Visible <- true

    let run() =
        while true do
            try
                let _ = Console.ReadLine()
                win.Invalidate()
            with _ ->
                printfn "ERROR"

    let thread = Thread(ThreadStart(run), IsBackground = true)
    thread.Start()

    let mutable i = 0
    while win.Exists do
        win.ProcessEvents()
        printfn "did something: %A" i
        i <- i + 1

    0
