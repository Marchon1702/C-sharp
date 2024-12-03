using E_commerce_Loja_de_Roupas.Models;

internal class ProdutosGeral()
{
    public static IEnumerable<Produto> produtos = new List<Produto>
    { 
                // Camisas
                new Produto("Camiseta Estampada", "Camiseta de algodão com estampa frontal", 29.90, "Camisas", "M", 50),
                new Produto("Camiseta Básica", "Camiseta simples, ideal para o dia a dia", 19.90, "Camisas", "G", 30),
                new Produto("Camiseta de Banda", "Camiseta com estampa de banda famosa", 39.90, "Camisas", "GG", 25),
                new Produto("Camiseta Polo", "Camiseta polo de algodão, ideal para o verão", 49.90, "Camisas", "M", 40),
                new Produto("Camiseta com Manga Longa", "Camiseta de manga longa, ótima para o outono", 59.90, "Camisas", "P", 20),
                new Produto("Camiseta Colorida", "Camiseta de várias cores, com opções vibrantes", 34.90, "Camisas", "G", 35),
                new Produto("Camiseta Fitness", "Camiseta ideal para prática de atividades físicas", 69.90, "Camisas", "M", 50),
                new Produto("Camiseta Social", "Camiseta social de manga curta, para eventos casuais", 79.90, "Camisas", "G", 15),
                new Produto("Camiseta Estilo Vintage", "Camiseta com design retrô e logo vintage", 45.90, "Camisas", "M", 60),
                new Produto("Camiseta Estilo Geek", "Camiseta com estampa geek para os fãs de cultura pop", 49.90, "Camisas", "G", 45),

                // Casacos
                new Produto("Casaco de Lã", "Casaco quente de lã para o inverno", 129.90, "Casacos", "M", 20),
                new Produto("Casaco Trench Coat", "Casaco elegante estilo trench coat", 159.90, "Casacos", "G", 15),
                new Produto("Casaco de Pele Sintética", "Casaco de pele sintética para ocasiões especiais", 199.90, "Casacos", "M", 10),
                new Produto("Jaqueta de Couro", "Jaqueta de couro de alta qualidade, estilo urbano", 219.90, "Casacos", "G", 8),
                new Produto("Casaco Puffer", "Casaco puffer de inverno, super quentinho", 169.90, "Casacos", "M", 25),
                new Produto("Casaco de Moletom", "Casaco confortável de moletom, perfeito para o dia a dia", 89.90, "Casacos", "G", 50),
                new Produto("Casaco de Inverno", "Casaco de inverno com capô e forro interno", 109.90, "Casacos", "P", 18),
                new Produto("Casaco Bomber", "Casaco estilo bomber, com zíper e bolsos", 129.90, "Casacos", "GG", 12),
                new Produto("Casaco de Cashmere", "Casaco de cashmere macio e elegante", 299.90, "Casacos", "M", 5),
                new Produto("Casaco Oversized", "Casaco oversized, com design descontraído", 139.90, "Casacos", "G", 20),

                // Shorts
                new Produto("Shorts de Praia", "Shorts leves para usar na praia", 49.90, "Shorts", "P", 100),
                new Produto("Shorts Jeans", "Shorts jeans confortável e durável", 69.90, "Shorts", "M", 80),
                new Produto("Shorts de Cintura Alta", "Shorts com cintura alta e moderno", 59.90, "Shorts", "G", 70),
                new Produto("Shorts Estampado", "Shorts com estampa tropical, ideal para o verão", 59.90, "Shorts", "M", 50),
                new Produto("Shorts Esportivo", "Shorts com material leve para atividades físicas", 79.90, "Shorts", "P", 60),
                new Produto("Shorts Ciclista", "Shorts estilo ciclista, confortável e adequado", 69.90, "Shorts", "M", 40),
                new Produto("Shorts de Algodão", "Shorts de algodão para conforto diário", 39.90, "Shorts", "G", 90),
                new Produto("Shorts Cargo", "Shorts cargo com vários bolsos e design utilitário", 89.90, "Shorts", "GG", 30),
                new Produto("Shorts de Corrida", "Shorts técnico para corrida e esportes", 79.90, "Shorts", "M", 50),
                new Produto("Shorts de Linho", "Shorts de linho, ideal para clima quente", 69.90, "Shorts", "G", 20),

                // Calças
                new Produto("Calça Jeans Skinny", "Calça jeans skinny com stretch", 89.90, "Calças", "38", 40),
                new Produto("Calça de Sarja", "Calça de sarja confortável e leve", 79.90, "Calças", "40", 25),
                new Produto("Calça de Moletom", "Calça de moletom, perfeita para o inverno", 99.90, "Calças", "G", 50),
                new Produto("Calça Jogger", "Calça jogger com design esportivo e confortável", 109.90, "Calças", "M", 40),
                new Produto("Calça de Lã", "Calça de lã para clima frio, ideal para o inverno", 129.90, "Calças", "42", 20),
                new Produto("Calça Chino", "Calça chino de algodão, casual e elegante", 119.90, "Calças", "44", 60),
                new Produto("Calça de Veludo", "Calça de veludo macio e confortável", 139.90, "Calças", "38", 15),
                new Produto("Calça Social", "Calça social de alfaiataria para eventos formais", 149.90, "Calças", "40", 25),
                new Produto("Calça Cargo", "Calça cargo estilo militar, com bolsos laterais", 99.90, "Calças", "42", 30),
                new Produto("Calça Pantacourt", "Calça pantacourt com design moderno e confortável", 109.90, "Calças", "44", 20),

                // Sapatos
                new Produto("Tênis Esportivo", "Tênis confortável e ideal para atividades físicas", 139.90, "Sapatos", "42", 15),
                new Produto("Sandália de Couro", "Sandália casual de couro legítimo", 99.90, "Sapatos", "39", 30),
                new Produto("Bota de Couro", "Bota de couro resistente para clima frio", 179.90, "Sapatos", "43", 10),
                new Produto("Tênis Casual", "Tênis casual para o dia a dia, confortável e moderno", 129.90, "Sapatos", "40", 40),
                new Produto("Tênis de Corrida", "Tênis técnico para corredores, com amortecimento avançado", 159.90, "Sapatos", "41", 25),
                new Produto("Botas de Trabalho", "Botas robustas para trabalho e segurança", 219.90, "Sapatos", "44", 15),
                new Produto("Mocassim", "Mocassim de couro, ideal para ocasiões formais", 169.90, "Sapatos", "39", 30),
                new Produto("Tênis Slip-on", "Tênis sem cadarço, confortável e prático", 109.90, "Sapatos", "42", 50),
                new Produto("Tênis Skate", "Tênis resistente, ideal para praticantes de skate", 139.90, "Sapatos", "43", 20),
                new Produto("Sapatênis", "Sapatênis casual, para um look descontraído", 119.90, "Sapatos", "40", 35),

                // Bonés
                new Produto("Boné de Beisebol", "Boné estilo beisebol com logo bordado", 39.90, "Bonés", "Único", 150),
                new Produto("Boné Snapback", "Boné snapback com design moderno", 49.90, "Bonés", "Único", 100),
                new Produto("Boné Trucker", "Boné com a parte traseira de rede, para clima quente", 29.90, "Bonés", "Único", 200),
                new Produto("Boné de Aba Curvada", "Boné com aba curvada, ideal para o estilo streetwear", 45.90, "Bonés", "Único", 80),
                new Produto("Boné de Lã", "Boné de lã para o inverno, ideal para proteger do frio", 59.90, "Bonés", "Único", 40),
                new Produto("Boné Fashion", "Boné com detalhes sofisticados e design fashion", 69.90, "Bonés", "Único", 60),
                new Produto("Boné de Logo", "Boné com logo grande e estiloso na frente", 49.90, "Bonés", "Único", 120),
                new Produto("Boné Com Estampa", "Boné com estampa criativa e colorida", 59.90, "Bonés", "Único", 90),
                new Produto("Boné de Algodão", "Boné de algodão confortável, ideal para o verão", 34.90, "Bonés", "Único", 150),
                new Produto("Boné Vintage", "Boné com estilo retrô e logo vintage", 44.90, "Bonés", "Único", 110)
    };


}
