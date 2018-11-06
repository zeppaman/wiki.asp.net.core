using PagedList;
using System;
using System.Collections.Generic;
using System.Text;
using WikiCore.Lib.BLL.BO;
using WikiCore.Lib.DTO;

namespace WikiCore.Lib.BLL
{
    public interface IWikiPageService
    {
        WikiPageDTO GetPage(string slug);
        WikiPageDTO GetPageRevision(string slug, int version);
        WikiPageDTO Save(WikiPageBO item);
        IPagedList<WikiPageDTO> GetAllPages(string search, int start, int size);
    }
}
