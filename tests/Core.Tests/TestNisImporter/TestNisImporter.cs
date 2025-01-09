using S100Framework.Applications;

namespace TestNisImporter
{
    public class TestNisImporter
    {
        [Fact]
        public void NoteLoaderTest() {
            var notesPath = @"G:\indigo\ENC\NotesAndPictures";

            foreach (var notePath in Directory.GetFiles(notesPath, "*.txt", SearchOption.AllDirectories)) {
                var note = new Note(notePath);
                //Assert.True(string.IsNullOrEmpty(note.Header));
                Assert.True(!string.IsNullOrEmpty(note.Content));

            }
        }
    }
}