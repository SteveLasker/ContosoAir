import { Component, Input, OnInit, OnChanges} from '@angular/core';
import { BookingService } from '../shared/booking.service';
import { Flight } from './flight';

@Component({
    selector: 'results',
    templateUrl: './results.component.html'
})
export class ResultsComponent implements OnInit, OnChanges{
    @Input('flights') flights: (Flight)[];
    @Input('id') id: number;
    @Input('direction') direction: string;
    selected: number;
    booking: any;

    constructor(private bookingService: BookingService){}

    ngOnInit() {
        this.booking = this.bookingService.get();
        this.selected = this.id;
    }

    ngOnChanges(flights) {
        if(this.flights){            
            let flight = this.flights.filter(data => data.id === this.selected)[0];
            this.set(flight);
        }
    }

    set(flight: Flight):void{
        this.selected = flight.id;
        this.booking[this.direction] = flight;
    }

}
