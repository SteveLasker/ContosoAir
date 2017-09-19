import { Component, OnInit } from '@angular/core';
import { FlightsService } from './flights.service';
import { Router } from '@angular/router';
import { BookingService } from '../shared/booking.service';
import { Flight } from './flight';

@Component({
    providers: [ FlightsService ],
    templateUrl: './flights.component.html'
})
export class FlightsComponent implements OnInit{
    flights_there: (Flight)[];
    flights_back: (Flight)[];
    booking: any;
    FlightsReady: boolean;

    constructor(private flightsService: FlightsService, private parentRouter: Router, private bookingService: BookingService){}

    ngOnInit() {
        this.booking = this.bookingService.get();
        setTimeout(() => {
            this.flightsService.get().subscribe(
                res => {
                    this.flights_there = res.filter(data => data.fromCode === 'SEA');
                    this.flights_back = res.filter(data => data.fromCode === 'BCN');
                    this.FlightsReady = true;
                },
                err => {
                    console.log(err);
                }
            );
        }, 2500);

    }

    setBooking(){
        this.parentRouter.navigateByUrl('/seats');
    }
}
