import { Injectable } from '@angular/core';
import { TweetContent } from '../models/tweet.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TweetService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = 'https://localhost:44332/api/tweet';
  tweetData: TweetContent = new TweetContent();
  tweetsList: TweetContent[] = [];

  postTweet() {
    this.tweetData.dateCreated = new Date();
    return this.http.post(this.baseUrl, this.tweetData);
  }

  refreshList() {
    this.http.get(this.baseUrl)
      .toPromise()
      .then(res => {
        let temp = res as TweetContent[];
        this.tweetsList = temp.sort(((a, b) => {
          return <any>new Date(b.dateCreated) - <any>new Date(a.dateCreated);
        }))
      })
  }
}
