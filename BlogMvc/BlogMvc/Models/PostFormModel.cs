using BlogMvc.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogMvc.Models
{
    public class PostFormModel
    {
        public Post Post { get; set; } // Contiene tutti i dati da salvare
        public List<Category>? Categories { get; set; } // Categorie selezionabili (ci serve solo per mostrare alla view quali dati sono selezionabili)

        public List<SelectListItem>? Tags { get; set; } // Gli elementi dei tag selezionabili per la select (analogo a Categories)
        public List<string>? SelectedTags { get; set; } // Gli ID degli elementi effettivamente selezionati

        public IFormFile? ImageFormFile { get; set; } // Immagine da caricare

        public PostFormModel() { }

        public PostFormModel(Post p, List<Category> c)
        {
            this.Post = p;
            this.Categories = c;
        }

        public void CreateTags()
        {
            this.Tags = new List<SelectListItem>();
            this.SelectedTags = new List<string>();
            var tagsFromDB = PostManager.GetAllTags();
            foreach (var tag in tagsFromDB) // es. tag1, tag2, tag3... tag10
            {
                bool isSelected = this.Post.Tags?.Any(t => t.Id == tag.Id) == true;
                this.Tags.Add(new SelectListItem() // lista degli elementi selezionabili
                {
                    Text = tag.Title, // Testo visualizzato
                    Value = tag.Id.ToString(), // SelectListItem vuole una generica stringa, non un int
                    Selected = isSelected // es. tag1, tag5, tag9
                });
                if (isSelected)
                    this.SelectedTags.Add(tag.Id.ToString()); // lista degli elementi selezionati
            }
        }

        // Travasa i dati di ImageFormFile in Post.ImageFile (da IFormFile a byte[])
        public byte[] SetImageFileFromFormFile()
        {
            if (ImageFormFile == null)
                return null;

            using var stream = new MemoryStream();
            this.ImageFormFile?.CopyTo(stream);
            Post.ImageFile = stream.ToArray();

            return Post.ImageFile;
        }
    }
}
