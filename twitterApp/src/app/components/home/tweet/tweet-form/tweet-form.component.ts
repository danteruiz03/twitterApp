import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TweetService } from 'src/app/services/tweet.service';
import { TweetContent } from 'src/app/models/tweet.model';

@Component({
  selector: 'app-tweet-form',
  templateUrl: './tweet-form.component.html',
  styleUrls: ['./tweet-form.component.css']
})
export class TweetFormComponent implements OnInit {

  constructor(public service: TweetService) { }
  clicked: boolean = false;

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.clicked = true;
    setTimeout(() => this.submitForm(form), 2000);
  }

  submitForm(form: NgForm) {
    this.service.postTweet().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.clicked = false;
      }
    )
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.tweetData = new TweetContent();
  }
}
