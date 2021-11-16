// Eric Cool and Brett Bernardi
// Organization of Programming Languages
// Project

module OPL.Project.GeneratePrimes

open System

// Function that determines if `n1` can be divided by `n2`
let isDivisible n1 n2 =
    // modulus check
    n1 % n2 = 0

// Shows explicit type declarations
let isDivisible2 (n1: int) (n2: int) : bool =
    // modulus check
    n1 % n2 = 0

// Function that will calculate and return the square root of the Integer
// argument, and return an integer value.
let sqrttoint n = (int (sqrt (float n)))

// Function that determines if `number` is a prime
let isPrime number =
    // calculates square root of number, then floors the number by casting to int
    // inline lambda expression form of `sqrttoint`
    let max = (fun n -> (int (sqrt (float n)))) number

    // Create a list of numbers from `2` to `max`
    let range = [ 2 .. max ]

    // filter the range list [2-max]
    let listOfFactors =
        range |> List.filter (isDivisible (number))

    // return true if listOfFactors is zero!
    listOfFactors.IsEmpty

// Function to generate a list of primes up to the given `number`
let generatePrimes number =
    // Filter a list from [`2` => `number`] if they are prime
    let possiblePrimesList = [ 2 .. number ]
    // pipes possiblePrimesList to the List.filter function
    let primesList =
        possiblePrimesList |> List.filter (isPrime)

    primesList

// Function that will print out a list, with a new line inserted after
// every 10 elements
let printList list =
    let mutable count = 1

    // for ... in loop
    for num in list do
        printf "%5d " num
        if count % 10 = 0 then printf "\n"
        count <- count + 1

    list // return parameter list for piping


// Main Entry to the Application
[<EntryPoint>]
let main argv =

    printfn "Generate Prime Numbers\n\n"

    printf "Find prime numbers from 1 - "

    // Reads the input from the user
    let max = System.Console.ReadLine()

    // Attempt to parse the user input (max), storing it as an int
    // into number
    let mutable number = 0

    if Int32.TryParse(max, &number) then

        number // pipe `number` in to function pipeline
        |> generatePrimes // Generate a list of primes
        |> printList // Print out list of primes
        |> List.length // Get size of list of primes
        // Print out size of list of primes using a lambda expression
        |> (fun num -> printf "\n\n\nYou generated %d of primes!\n\n\n" num)

        0 // success
    else
        printfn "Error parsing input!"
        1 // failure
