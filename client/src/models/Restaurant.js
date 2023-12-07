import { RepoItem } from "./RepoItem.js"

export class Restaurant extends RepoItem {
  constructor (data) {
    super(data)
    // this.id = data.id
    this.name = data.name
    this.imgUrl = data.imgUrl
    this.description = data.description
    this.visits = data.visits
    this.isShutDown = data.isShutDown
    this.creatorId = data.creatorId
    this.reportCount = data.reportCount
    this.creator = data.creator
  }
}

let data = {
  "name": "Arby's",
  "imgUrl": "https://images.unsplash.com/photo-1529692236671-f1f6cf9683ba?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  "description": "Best restaurant in the entire world.",
  "visits": 0,
  "isShutDown": false,
  "creatorId": "65677a22619a399a33aeef33",
  "creator": {
    "name": "arbysmonster@arbys.monster",
    "picture": "https://s.gravatar.com/avatar/c35fc1254fa947387e2a7efb3d62c174?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Far.png",
    "id": "65677a22619a399a33aeef33",
    "createdAt": "2023-11-29T17:51:36",
    "updatedAt": "2023-11-29T17:51:36"
  },
  "id": 1,
  "createdAt": "2023-12-06T16:46:18",
  "updatedAt": "2023-12-06T16:46:18"
}