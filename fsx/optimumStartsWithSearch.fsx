
let search (txt: string) (words: list<string * int>) =
    let lookup = 
        words 
        |> List.groupBy (fun (k,_) -> k.[0..txt.Length - 1])
        |> Map.ofList
    lookup.[txt] 
    |> Seq.sortByDescending snd
    |> Seq.toArray


let words = [("iphone",400); ("ipad",300); ("ipod",20); ("galaxy",300)]

let term = "i"

let results = search term words

results |> Seq.iter (printf "%A\n")
