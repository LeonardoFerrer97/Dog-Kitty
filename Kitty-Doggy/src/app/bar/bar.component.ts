import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  styleUrls: ['./bar.component.css']
})
export class BarComponent implements OnInit {

  selectDisplay = 'none';

  constructor() { }

  ngOnInit(): void {
  }

  onClickText(){
    
  }
  onClickIcon(){
    if(this.selectDisplay = ''){
      this.selectDisplay = 'none';
    }
    if(this.selectDisplay = 'none'){
      this.selectDisplay = '';
    }
  }

  Login(){
    
  }

}
