import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'days',
    templateUrl: './days.component.html'
})
export class DaysComponent implements OnInit{
    @Input('date') date: Date;
    @Input('selected') selected: number;
    days: { date: Date, price: number }[];
    dates: Date[];

    constructor(){
        this.days = [];
    }

    ngOnInit() {
        for (let i = 0; i < 8; i++) {
            this.days[i] = {
                date: this.date,
                price: 0
            }; 
            this.days[i].date = this.moveDate(this.date, i-3);
            if(i === 3){
                this.days[i].price = this.selected;
            }else{
                this.days[i].price = 480 + Math.round(Math.random() * (100 - 30) + 30);
            }
        }
    }

    private moveDate(date: Date, days: number):Date{
        return new Date(date.getFullYear(), date.getMonth(), date.getDate() + days);
    }

}
