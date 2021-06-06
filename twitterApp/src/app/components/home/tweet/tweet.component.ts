import { Component, OnInit } from '@angular/core';
import { TweetService } from 'src/app/services/tweet.service';
import { faRetweet, faHeart, faComment, faShare } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-tweet',
  templateUrl: './tweet.component.html',
  styleUrls: ['./tweet.component.css']
})
export class TweetComponent implements OnInit {

  constructor(public service: TweetService) { }
  icons = {
    retweet: faRetweet,
    like: faHeart,
    comment: faComment,
    share: faShare
  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  calculateTime(tdateCreated: Date) {
    let now = new Date().getTime() / 1000;
    let dateCreated = new Date(tdateCreated);
    let time = (now - dateCreated.getTime() / 1000);

    if (time > 0 && time < 60) {
      return Math.floor(time) + 's'
    } else if (time >= 60 && time < 3600) {
      return Math.floor(time / 60) + 'm'
    } else if (time >= 3600 && time < 86400) {
      return Math.floor(time / 3600) + 'h'
    } else if (time >= 86400) {
      return dateCreated.toLocaleString('default', { month: 'short' }) + ' ' + dateCreated.getDate()
    } else {
      return null;
    }
  }
}
