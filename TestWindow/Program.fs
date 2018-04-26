// Learn more about F# at http://fsharp.org

open System
open System.Threading
open OpenTK.Platform
open OpenTK
open OpenTK.Graphics
open OpenTK.Graphics.OpenGL4

type MyGame() =
    inherit GameWindow(1024, 768, GraphicsMode.Default, "hi")
    let sw = System.Diagnostics.Stopwatch()
    let mutable frameCount = 0

    override x.OnRenderFrame(e) =
        
        GL.ClearColor(1.0f, 0.0f, 0.0f, 1.0f)
        GL.Clear(ClearBufferMask.ColorBufferBit)
        x.SwapBuffers()
        frameCount <- frameCount + 1
        if frameCount >= 20 then
            let dt = sw.Elapsed.TotalSeconds / float frameCount
            if dt > 0.0 then
                x.Title <- sprintf "%.2ffps" (1.0 / dt)
            frameCount <- 0
            sw.Restart()

    override x.OnKeyDown(e) =
        printfn "%A" e.Key
        if e.Key = OpenTK.Input.Key.Enter then
            x.RenderAsFastAsPossible <- not x.RenderAsFastAsPossible

[<EntryPoint>]
let main argv =
    use g = new MyGame()
    g.VSync <- VSyncMode.Off
    g.Run()

    use win = Factory.Default.CreateNativeWindow(100,100,800,600,"title",GraphicsMode.Default, OpenTK.GameWindowFlags.Fullscreen,OpenTK.DisplayDevice.Default)
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
