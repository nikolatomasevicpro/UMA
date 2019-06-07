import { Injectable } from '@angular/core';

import { QueryService } from '../../_base/query/query.service';
import { ConstServicesConf } from 'src/app/_models/config/consts/services.const';

import { GetProfileQuery } from 'src/app/_entities/profile/query/getProfile.query';
import { UpdateProfileQuery } from 'src/app/_entities/profile/query/updateProfile.query';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private query: QueryService) { }

  getProfile(query: GetProfileQuery) {
    return this.query.typedSend(ConstServicesConf.getProfile, query);
  }

  updateProfile(query: UpdateProfileQuery) {
    return this.query.typedSend(ConstServicesConf.updateProfile, query);
  }
}
