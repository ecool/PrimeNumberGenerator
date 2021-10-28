module OPL.Project.GeneratePrimes

open System

// Function that determines if `n1` can be divided by `n2`
let isDivisible n1 n2 =
    // modulus check
    n1 % n2 = 0

// Function that determines if `number` is a prime
let isPrime number =
    // list of numbers ranging from `12` => `(number / 2) + 1`
    let range =
        // Create 2 lists of
        // - the number - ex: [ 10 ]
        // - numbers up to half the number - ex: [ 1, 2, 3, 4, 5 ]
        // and join them together - ex: [ 10, 1, 2, 3, 4, 5 ]
        List.append [ number ] [ 1 .. ((number / 2)) ]
        // Filter the list by unique values (for #2)
        |> List.distinct

    // allow count to be changed (mutable)
    let mutable count = 0

    // iterate over the list `range`
    for num in range do
        // check if `number` can be divided by `num`
        if isDivisible number num then
            // increment the counter
            count <- count + 1
    // true/false
    count = 2 // if `count == 0` then it is a prime number

// Function to generate a list of primes up to the given `number`
let generatePrimes number =
    // Filter a list from [`2` => `number`] if they are prime
    List.filter isPrime [ 2 .. number ]

// Main Entry to the Application
[<EntryPoint>]
let main argv =
    printfn "Generate Prime Numbers"

    // Check that the program was given the needed number of arguments
    if argv.Length = 1 then
        // Number to generate up to
        let mutable number = 0

        // Attempt to parse the argument to an Integer
        if Int32.TryParse(argv.[0], &number) then
            printfn "Find prime numbers up to: %d" number
            // Generate a list of primes and print them
            printfn "%A" (generatePrimes number)
        else
            printfn "[ERROR] <number> argument could not be parsed."

        0 // success
    else
        printfn "[ERROR] Please run application with: `PrimeNumberGenerator.exe <number>`"
        1 // error
