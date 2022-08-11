import axios from "axios";
import { useEffect, useState } from "react";
import { CalculateInput } from "../models/calculate-input.model";
import { CalculateResult } from "../models/calculate-result.model";
import { getPrimeNumbers } from "../services/prime-number.service";

export function InputPrimeNumber() {

    const [primeNumbers, setPrimeNumber] = useState<CalculateResult>(null);

    async function fetchPrimeNumber(i) {
        const result = await getPrimeNumbers(i);
        console.log(result);
        setPrimeNumber(result);
    }

    return (
        <div>
            <input onChange={e => fetchPrimeNumber(e.target.value)} type="text" id="primeNumber" name="primeNumber" />
            <br />
            <div>
                Primos: {primeNumbers && primeNumbers.object.primeNumbers.map(m => <span>{m}, </span>)}
            </div>
            <br />
            <div>
                Divisores: {primeNumbers && primeNumbers.object.primeDivisorsNumbers.map(m => <span>{m}, </span>)}
            </div>
        </div>
    )
}