import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ShorturlapiService } from 'src/app/shorturlapi.service';
import {NgTinyUrlService} from 'ng-tiny-url';


@Component({
  selector: 'app-add-edit-shorturl',
  templateUrl: './add-edit-shorturl.component.html',
  styleUrls: ['./add-edit-shorturl.component.css']
})
export class AddEditShortUrlComponent implements OnInit {

  shorturlList$!: Observable<any[]>;

  constructor(private tinyUrlService: NgTinyUrlService, private service: ShorturlapiService) {  }
  linkcut: string = "";
  @Input() shorturl:any;
  id: number = 0;
  linkfull: string = "";
  

  ngOnInit(): void {
    this.id = this.shorturl.id;
    this.linkfull = this.linkfull;
    this.linkcut =  this.linkcut;
  }


  
  addLink() {
    this.tinyUrlService.shorten(this.linkfull).subscribe(res => {
        this.linkcut = res;
        var link = {
      linkfull:this.linkfull,
      linkcut:this.linkcut
        }
        this.service.addShortLink(link).subscribe(res => {

            var closeModalBtn = document.getElementById('add-edit-modal-close');
            if(closeModalBtn) {
              closeModalBtn.click();
            }
      
            var showAddSuccess = document.getElementById('add-success-alert');
            if(showAddSuccess) {
              showAddSuccess.style.display = "block";
            }
            setTimeout(function() {
              if(showAddSuccess) {
                showAddSuccess.style.display = "none"
              }
            }, 4000);
          })
      }         
    )
  }
}