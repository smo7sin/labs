
let compress chars =
    let rec compress' chars' count = seq {
        match chars' with
        | c1::c2::cx when c1 = c2 -> yield! compress' (c2::cx) (count+1)
        | c::cx -> yield (c, count); yield! compress' cx 1
        | _ -> ()
    }        
    compress' (chars |> Seq.toList) 1

let compChar (c, x) = if x > 1 then sprintf "%c%d" c x else sprintf "%c" c

let txt = stdin.ReadLine()

let output = 
    compress txt 
    |> Seq.map compChar

