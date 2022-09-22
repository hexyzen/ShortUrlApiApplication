import { NumberSymbol } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ShorturlapiService } from 'src/app/shorturlapi.service';


@Component({
  selector: 'app-show-shorturl',
  templateUrl: './show-shorturl.component.html',
  styleUrls: ['./show-shorturl.component.css']
})
export class ShowShorturlComponent implements OnInit {

  shorturlList$!:Observable<any[]>;

   //Map
   shorturlMap:Map<number,  string> = new Map() 

  constructor(private service:ShorturlapiService) { }

  ngOnInit(): void {
    this.shorturlList$ = this.service.getShorturlList();
  }

  modalTitle:string='';
  activateAddEditShorturlComponent:boolean = false;
  shorturl:any;

  
  modalAdd()
  {
   this.shorturl={
     id:0,
     linkfull:null,
     linkcut: null
   } 
   this.modalTitle = "Add Link";
   this.activateAddEditShorturlComponent = true; 
  }


  delete(item:any) {
    if(confirm(`Are you sure you want to delete link${item.id}`)) {
      this.service.deleteShortLink(item.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn) {
        closeModalBtn.click();
      }

      var showDeleteSuccess = document.getElementById('delete-success-alert');
      if(showDeleteSuccess) {
        showDeleteSuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showDeleteSuccess) {
          showDeleteSuccess.style.display = "none"
        }
      }, 4000);
      this.shorturlList$ = this.service.getShorturlList();
      })
    }
  }

  modalClose(){
    this.activateAddEditShorturlComponent = false;
    this.shorturlList$ = this.service.getShorturlList();
  }

}
