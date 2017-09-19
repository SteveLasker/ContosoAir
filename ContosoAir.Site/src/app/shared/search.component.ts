import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { AirportsService } from './airports.service';
import { BookingService } from './booking.service';
import { Airport } from './airport';

@Component({
    selector: 'search',
    providers: [ AirportsService ],
    templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit{
    airports: (Airport)[];
    @Input('city') city: string;
    @Output() onSearchReady = new EventEmitter<boolean>();
    booking: any;
    hasFocus: boolean;
    startDate: { year: number, month: number, day: number };
    endDate: { year: number, month: number, day: number };

    constructor(private airportsService: AirportsService, private parentRouter: Router, private bookingService: BookingService){
        this.booking = {
            fromAirport: {
                code: '',
                name: '',
                city: '',
                country: ''
            },
            toAirport: {
                code: '',
                name: '',
                city: '',
                country: ''
            }
        };
    }

    ngOnInit() {
        if(this.city === 'BCN'){
            const date = new Date();
            let startDate = this.moveDate(date, 15);
            let endDate =  this.moveDate(date, 30);
             this.startDate= { year: startDate.getFullYear(), month: startDate.getMonth() + 1, day: startDate.getDate() };
             this.endDate= { year: endDate.getFullYear(), month: endDate.getMonth() + 1, day: endDate.getDate() };
        }
        this.airportsService.get().subscribe(
            res => {
                //this.airports 
                let airports = res.sort(function(a, b){
                    if(a && b && a.city && b.city && typeof a.city === 'string' && typeof b.city === 'string'){
                        let nameA = a.city.toUpperCase();
                        let nameB = b.city.toUpperCase();
                        if (nameA < nameB) {
                            return -1;
                        }
                        if (nameA > nameB) {
                            return 1;
                        }
                    }
                    return 0;
                });

                let selectFrom = document.getElementById('fromDestination');
                let selectTo = document.getElementById('toDestination');

                //add API options
                for (let airport of airports) {
                    if(airport.code && airport.city){
                        let optionFrom = document.createElement('option');
                        let optionTo = document.createElement('option');
                        optionFrom.value = optionTo.value = airport.code;
                        optionFrom.innerHTML = optionTo.innerHTML = airport.city + ' ' + airport.code;
                        if(this.city && this.city === airport.code){
                            optionTo.selected = true;
                        }
                        if(this.city === 'BCN' && airport.code === 'SEA'){
                            optionFrom.selected = true;
                        }
                        selectFrom.appendChild(optionFrom);
                        selectTo.appendChild(optionTo);

                    }
                }
                this.onSearchReady.emit(true);
            },
            err => {
                console.log(err);
            }
        );
    }

    focus() {
      this.hasFocus = true;
    }

    setBooking(){
        let date = new Date();
        if(!this.startDate){
            this.booking.startDate = this.moveDate(date, 1);
        }else{
            this.booking.startDate = this.convertDate(this.startDate.year, this.startDate.month, this.startDate.day);
        }

        if(!this.endDate){
            this.booking.endDate = this.moveDate(this.booking.startDate, 7);
        }else{
            this.booking.endDate = this.convertDate(this.endDate.year, this.endDate.month, this.endDate.day);
        }

        this.bookingService.set(this.booking);
        this.parentRouter.navigateByUrl('/flights');
    }

    private moveDate(date: Date, days: number):Date{
        return new Date(date.getFullYear(), date.getMonth(), date.getDate() + days);
    }

    private convertDate(year: number, month: number, day: number):Date{
        return new Date(year, month - 1, day);
    }

}
