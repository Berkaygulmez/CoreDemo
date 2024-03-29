﻿using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriğini boş geçemezsiniz.");
            RuleFor(x => x.Blogİmage).NotEmpty().WithMessage("Blog Görselini boş geçemezsiniz.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 4 karakterden daha fazla veri girişi yapınız");
        }
    }
}
