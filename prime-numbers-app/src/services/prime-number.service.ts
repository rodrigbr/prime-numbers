import Axios from "axios";

export async function getPrimeNumbers(number: number) {

    return Axios
        .post('http://localhost:38772/api/PrimeNumber/CalculatePrimeNumbers', { number })
        .then(res => res.data);
}