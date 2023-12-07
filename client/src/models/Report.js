import { RepoItem } from "./RepoItem.js";

export class Report extends RepoItem {
  constructor (data) {
    super(data)
    this.title = data.title
    this.body = data.body
    this.pictureOfDisgust = data.pictureOfDisgust
    this.restaurantId = data.restaurantId
    this.creatorId = data.creatorId
    this.creator = data.creator
  }
}

// let data = {
//   "title": "Why eat here when other places exist",
//   "body": "I don't like burgers!",
//   "pictureOfDisgust": null,
//   "restaurantId": 2,
//   "creatorId": "65496e4fb47d5e23a481b288",
//   "creator": {
//     "name": "jerms@jerms.jerms",
//     "picture": "https://s.gravatar.com/avatar/c2161d4c4a6d8087b112d5e9d41c3c88?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fje.png",
//     "id": "65496e4fb47d5e23a481b288",
//     "createdAt": "2023-11-29T16:42:51",
//     "updatedAt": "2023-11-29T16:42:51"
//   },
//   "id": 1,
//   "createdAt": "2023-12-07T18:44:44",
//   "updatedAt": "2023-12-07T18:44:44"
// }