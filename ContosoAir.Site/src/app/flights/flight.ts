export interface Flight {
    id: number,
    duration: string,
    price: string,
    fromCode: string,
    toCode: string,
    distance: string,
    segments: {
    	flight: string,
    	fromCode: string,
    	departTime: string,
    	toCode: string,
    	arrivalTime: string
    }[]
}