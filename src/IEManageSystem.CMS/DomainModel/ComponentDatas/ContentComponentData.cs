﻿using Abp.Domain.Entities;
using IEManageSystem.CMS.DomainModel.PageDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace IEManageSystem.CMS.DomainModel.ComponentDatas
{
    public class ContentComponentData : Entity
    {
        /// <summary>
        /// 组件标识
        /// </summary>
        public string Sign { get; set; }

        public string Discriminator { get; protected set; }

        public ICollection<ComponentSingleData> SingleDatas { get; set; }

        public PageData PageData { get; set; }

        [ForeignKey("PageData")]
        public int? PageDataId { get; set; }

        public ComponentSingleData CreateSingleData(string name)
        {
            var sortIndex = 0;

            if (SingleDatas.Count > 0)
            {
                sortIndex = SingleDatas.Max(e => e.SortIndex) + 1;
            }

            ComponentSingleData single = new ComponentSingleData()
            {
                Name = name,
                SortIndex = sortIndex,
            };

            SingleDatas.Add(single);

            return single;
        }

        public void DeleteSingleData(int id)
        {
            var single = SingleDatas.FirstOrDefault(e => e.Id == id);
            if (single == null)
            {
                return;
            }

            SingleDatas.Remove(single);
        }

        public IEnumerable<ComponentSingleData> GetSingleDatas(string name)
        {
            return SingleDatas.Where(e => e.Name == name);
        }

        public ComponentSingleData GetOrCreateSingleData(string name)
        {
            var single = SingleDatas.FirstOrDefault(e => e.Name == name);
            if (single == null)
            {
                return CreateSingleData(name);
            }

            return single;
        }
    }
}
