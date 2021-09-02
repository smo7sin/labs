

let paths = ["root/documents/file1.txt"; "root/download/fld1/image.jpg"; "root/documents/file2.txt"; "root/download/image1.jpg"]

let splitPath (s:string) =
    s.Split('/')
    |> Array.toList

type Tree =
    | Leaf of string
    | Node of string * Tree seq

let list2Tree list =
    let rec recurse ls =
        match ls with
        | [] -> Leaf ""
        | [x] -> Leaf x
        | x::xs -> Node (x, Seq.singleton (recurse xs))
    recurse list


let seq2Tree (list: string seq) = 
    let rec recurse ls = 
        let tail = ls |> Seq.tail
        let head = ls |> Seq.head

        if (tail |> Seq.isEmpty) then
            Leaf head
        else
            Node (head, Seq.singleton (recurse tail))

    recurse list

let rec merge brs1 brs2 = seq {
    let h1 = brs1 |> Seq.head
    let h2 = brs2 |> Seq.head
    let t1 = brs1 |> Seq.tail
    let t2 = brs2 |> Seq.tail

    match (h1, h2) with
    | (Node (n1, xs1), Node (n2, xs2)) when n1 = n2 -> yield Node (n1, merge xs1 xs2)
    | _ -> yield! seq[h1; h2]

    if not (t1 |> Seq.isEmpty) && not (t2 |> Seq.isEmpty) then
        yield! merge t1 t2
    
    yield! t1 |> Seq.append t2   
}
  
let makeTree (paths: string seq) = 
    paths 
    |> Seq.sort
    |> Seq.map (splitPath >> seq2Tree >> Seq.singleton)
    |> Seq.reduce merge
    |> Seq.exactlyOne


makeTree paths