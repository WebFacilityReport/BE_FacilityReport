﻿using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.RepositoryImp
{
    public class ImageRepositoryImp : GenericRepositoryImp<Image>,IImageRepository
    {
        public ImageRepositoryImp(FacilityReportContext context) : base(context)
        {
        }
    }
}
