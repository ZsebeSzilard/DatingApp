import { Component, OnInit } from '@angular/core';
import { NgxGalleryThumbnailsComponent } from '@kolkov/ngx-gallery';
import { Member } from '../_models/member';
import { Pagination } from '../_models/pagination';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  members!: Member[];
  predicate: string = 'liked';
  pageNumber = 1;
  pageSize = 5;
  pagination!: Pagination;

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.loadLikes();
  }

  loadLikes(){
    this.memberService.getLikes(this.predicate, this.pageNumber, this.pageSize).subscribe((response:any)=>{
      this.members = response.result;
      this.pagination = response.pagination;
    })
  }

  pageChanged(event: any){
    this.pageNumber = event.page;
    this.loadLikes();
  }

}
