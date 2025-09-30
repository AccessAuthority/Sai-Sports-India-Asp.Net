using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SaiSports.Models;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SaiSports.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;
        private readonly EmailSender _emailSender;

        public HomeController(AppDbContext context, IWebHostEnvironment environment, EmailSender emailSender)
        {
            _context = context;
            _environment = environment;
            _emailSender = emailSender;

        }

        // Hardcoded list of services (no database)
        private List<Service> GetServices()
        {
            return new List<Service>
    {
        new Service
{
    Title = "Cloth Manufacturing",
    short_dsec="We specialize in the design and production of custom uniforms and branded merchandise tailored specifically for sports teams.",
    Description = @"
        <p>At our core, we specialize in the design and production of custom uniforms and branded merchandise tailored specifically for sports teams. Whether you’re a professional league, a local club, a school team, or a recreational league, we are committed to providing high-quality, durable uniforms that cater to the unique needs of athletes across various sports disciplines.</p>
        
        <h3>Quality, Durability, and Comfort</h3>
        <p>We understand that a uniform is more than just clothing—it’s a tool that plays a crucial role in athlete performance. That’s why we ensure every uniform we create is not only visually impactful but also comfortable and functional. Our fabrics and materials are carefully selected for their durability, breathability, and performance, ensuring that every athlete can perform at their best without distractions.</p>
        
        <p>Whether your team competes in high-intensity games or trains daily, our uniforms are designed to withstand the rigors of the sport, offering a long-lasting investment. From moisture-wicking fabrics to flexible, lightweight materials, we prioritize athlete comfort while maintaining the highest standards of craftsmanship.</p>
        
        <h3>Custom Designs for Every Team</h3>
        <p>Our design process is rooted in collaboration. We know that no two teams are alike, and each has its own unique identity. That’s why our design team works closely with you to create uniforms that reflect your team’s logo, colors, and branding. Whether you’re looking for a sleek, modern aesthetic or a classic, bold design, we ensure that every detail is tailored to your vision.</p>
        
        <p>From home and away jerseys to practice gear, shorts, socks, and more, we can create a cohesive look that strengthens your team’s identity both on and off the field. Our uniforms are designed to not only enhance your athletes’ performance but also to inspire team spirit and pride.</p>
        
        <h3>Crafted for Every Athlete</h3>
        <p>Fit and function are key elements when it comes to uniform design. We take the time to consider every detail—ensuring that every uniform provides maximum comfort and flexibility for athletes during both games and training sessions. We offer a variety of sizing options, custom tailoring, and design adjustments to ensure that each uniform fits each athlete perfectly, allowing for freedom of movement and peak performance.</p>
        
        <h3>Cutting-Edge Manufacturing Techniques</h3>
        <p>Our commitment to excellence extends beyond design. We utilize cutting-edge manufacturing techniques to produce uniforms that meet the highest standards of quality. Our advanced production processes ensure precision in every stitch, every color, and every logo, guaranteeing that your team’s uniforms will be as durable and reliable as they are stylish.</p>
        
        <p>We employ innovative techniques such as sublimation printing, embroidery, and screen printing, depending on the specific needs of the design. Each uniform undergoes rigorous quality control checks to ensure consistency and perfection in every garment.</p>
        
        <h3>A Partner for Teams of All Sizes</h3>
        <p>Whether you’re outfitting a professional sports team or a community-based recreational league, we are dedicated to providing personalized service to teams of all sizes. From initial consultation to the final product delivery, we are with you every step of the way to ensure that your uniforms meet your specific needs and exceed your expectations.</p>
        
        <p>We also offer a range of branded merchandise, from hats and bags to training gear and accessories, so your team can show off their colors wherever they go.</p>
        
        <h3>Conclusion</h3>
        <p>At the end of the day, we are passionate about helping teams perform at their best while representing their identity with pride. From the quality and durability of our materials to the custom design options we offer, every aspect of our process is focused on one goal: to give your team uniforms that not only look great but also help you play your best. With our commitment to craftsmanship and our attention to detail, you can trust us to provide uniforms that your athletes will love to wear, game after game.</p>
        
        <p>Get in touch with us today to start designing the perfect uniforms for your team!</p>
    ",
    ImageUrl = "clothes.png"
},

        new Service
{
    Title = "Bulk or Clothing Production",
    short_dsec="We provide efficient production and timely delivery of bulk orders for sports clubs, schools, and government institutions, ensuring consistent quality and attention to detail across large quantities.",
    Description = @"
        <p>We provide efficient production and timely delivery of bulk orders for sports clubs, schools, and government institutions, ensuring consistent quality and attention to detail across large quantities. Whether you're outfitting an entire league, a corporate event, or a school district, we manage bulk orders efficiently while maintaining a high standard of quality.</p>
        
        <h3>Streamlined Production Process</h3>
        <p>Our production process is designed to streamline large orders without compromising the integrity of the products. Each item, from jerseys and pants to socks and accessories, is crafted with the same precision and care as a single custom order. We believe that quality should never be sacrificed, even when producing items in bulk.</p>

        <p>Our experienced team handles every step of the production process, from initial design and ordering to final delivery, ensuring that all orders meet our high standards. We use advanced technology and skilled craftsmanship to ensure each product maintains consistency, even across large quantities.</p>

        <p>Additionally, our robust logistics system ensures that orders of any size are tracked and processed efficiently, minimizing delays and ensuring timely delivery. We take pride in our ability to fulfill bulk orders quickly, whether it's a seasonal rush or a large, ongoing supply for your institution.</p>

        <h3>Timely Delivery and Deadlines</h3>
        <p>We understand the importance of meeting deadlines. Whether you need the order for a sports season, a corporate event, or an academic year, we work closely with our clients to ensure that all orders are delivered on time and within budget. We pride ourselves on our quick turnaround times without compromising the quality of the final products.</p>

        <p>Our team has developed a deep understanding of the urgency that comes with bulk orders, which is why we have perfected our process to minimize wait times. We plan every step meticulously and anticipate potential delays, ensuring that we meet your specific deadlines with ease.</p>

        <h3>Quality Control and Consistency</h3>
        <p>We ensure that each item produced meets our stringent quality control standards. Whether it’s a batch of uniforms or branded apparel for a corporate event, we take every measure to guarantee that every product is defect-free and matches the agreed-upon specifications. Our attention to detail remains consistent across every order, large or small.</p>

        <p>From fabric selection to stitching quality, color accuracy, and custom branding, we scrutinize every step of production to maintain a high-quality result. Our dedicated quality control team performs regular checks throughout the manufacturing process to catch any issues early and resolve them before they affect the final product.</p>

        <h3>Competitive Pricing for Bulk Orders</h3>
        <p>Our bulk production services come with competitive pricing, making us the ideal partner for large-scale clothing production. We balance cost-efficiency with quality to provide you with the best value for your investment. Our goal is to help you outfit your teams, staff, or students with top-tier apparel without exceeding your budget.</p>

        <p>By leveraging our long-standing relationships with fabric suppliers and optimizing our production lines, we’re able to offer you substantial savings on bulk orders. These savings are passed directly onto you, providing a great return on investment, even for large-scale orders.</p>

        <h3>Your Ideal Partner for Large-Scale Production</h3>
        <p>From the initial consultation to the final delivery, we are committed to providing a smooth and hassle-free experience for every bulk order. We’re here to ensure that your large-scale clothing production runs as efficiently as possible while maintaining the highest standards of quality. No matter the size of your order, we treat every customer with the same level of care and attention to detail.</p>

        <p>Whether you're placing an order for a sports team, school district, corporate event, or government institution, we are the reliable and trusted partner for your bulk production needs. Our goal is to make the process as simple as possible, from the moment you inquire to the final delivery of your custom products.</p>

        <h3>End-to-End Customer Service</h3>
        <p>At the heart of our business is a commitment to excellent customer service. We work closely with our clients from start to finish, offering personalized support to help you through every step of the process. Our dedicated project managers ensure that communication is seamless, keeping you informed of the status of your order and addressing any questions or concerns along the way.</p>

        <p>Our customer service doesn't stop once the order is delivered. We offer after-sale support to ensure that you are fully satisfied with the final product and the overall experience. Our team is always available to assist with any post-delivery needs, whether you need adjustments, additional products, or guidance on maintaining the quality of your apparel over time.</p>

        <h3>Why Choose Us for Your Bulk Clothing Production?</h3>
        <ul>
            <li><strong>Efficiency:</strong> We excel at handling large orders with fast turnaround times.</li>
            <li><strong>Quality:</strong> Consistent, high-quality production without compromise.</li>
            <li><strong>Customization:</strong> Full customization options for branding and team identity.</li>
            <li><strong>Competitive Pricing:</strong> Great value for large orders, without sacrificing quality.</li>
            <li><strong>Customer Support:</strong> Dedicated project managers and after-sale assistance.</li>
        </ul>

        <p>Let us handle your bulk clothing production needs—whether for a sports league, a school district, or a corporate event. With our efficient process, competitive pricing, and focus on high-quality standards, we’re the perfect partner for your large-scale apparel needs.</p>
    ",
    ImageUrl = "textile (4).png"
},
     new Service
{
    Title = "Fabric Sourcing and Supply",
    short_dsec="Our fabric sourcing and supply services offer premium, high-performance materials that are carefully selected to ensure quality, durability, and comfort in every garment.",
    Description = @"
        <p>Our fabric sourcing and supply services offer premium, high-performance materials that are carefully selected to ensure quality, durability, and comfort in every garment. Whether you’re looking for breathable, moisture-wicking fabrics for hot weather sports or insulating, warm materials for cold weather conditions, we have the right options to suit your needs.</p>
        
        <h3>Tailored Fabric Solutions for Every Need</h3>
        <p>We understand that every sport and activity has specific requirements when it comes to fabric. Our vast selection of fabrics is chosen to meet the unique needs of athletes, providing materials that not only look great but also perform exceptionally well. From lightweight, breathable fabrics that wick away moisture to heavy-duty, durable materials that withstand tough conditions, we ensure that every garment is made to enhance performance and comfort.</p>

        <p>For sports that require breathability and moisture management, like soccer, basketball, and running, we offer fabrics designed to keep athletes dry and comfortable. For colder weather sports like skiing or ice hockey, we provide insulated materials that keep athletes warm without adding bulk. No matter the condition or activity, we ensure that your team’s apparel is built with the best materials for the task at hand.</p>

        <h3>Quality and Durability</h3>
        <p>We work with only trusted, reliable suppliers who meet our high standards for both quality and sustainability. Our fabrics are tested for durability and designed to withstand the wear and tear that comes with intense training and competition. From extended exposure to sunlight and sweat to frequent washing, our materials retain their strength, shape, and performance over time.</p>

        <p>Our sourcing partners are carefully selected to ensure they meet our high-quality benchmarks, guaranteeing that you receive fabrics that stand the test of time and keep your athletes performing at their best, season after season.</p>

        <h3>Sustainability and Eco-Friendly Materials</h3>
        <p>We are committed to sustainability and offer eco-friendly fabrics that are produced with minimal environmental impact. From recycled polyester to organic cotton, we provide options that are both high-performing and environmentally responsible. Our eco-friendly materials help reduce the environmental footprint of your team’s apparel without compromising on quality or performance.</p>

        <p>By choosing sustainable fabrics, you not only help preserve the environment but also support the growing demand for responsible sourcing in the fashion and sportswear industries. We are proud to offer fabrics that combine both performance and sustainability, ensuring that your team can feel good about their apparel choices.</p>

        <h3>Performance-Enhancing Materials</h3>
        <p>Our fabric selection includes performance-enhancing materials designed to improve athlete comfort, support peak performance, and ensure the longevity of each garment. We offer moisture-wicking fabrics that keep athletes dry and cool during high-intensity workouts, as well as stretchable, flexible fabrics that allow for full range of motion, providing athletes with the freedom they need to perform at their best.</p>

        <p>For sports requiring extra support and durability, such as rugby, football, or wrestling, we offer heavy-duty fabrics designed to withstand the toughest physical demands. Each material we supply is chosen not only for its appearance but for its ability to withstand the most demanding conditions athletes face.</p>

        <h3>Custom Fabric Solutions for Every Sport</h3>
        <p>We take into consideration the specific requirements of each sport, such as flexibility, durability, breathability, and moisture management, to provide you with the perfect material for your custom sportswear. Whether it’s a lightweight, quick-drying fabric for running gear or a heavier, water-resistant material for outerwear, we can source and supply the ideal fabric for your team’s needs.</p>

        <p>Our experienced fabric experts will work with you to understand your needs and recommend the best fabric options based on the unique demands of the sport, your team’s climate, and your budget. We’re here to ensure that you get the best quality materials for every aspect of your team’s uniform, from jerseys to training gear and outerwear.</p>

        <h3>Long-Lasting Garments Built for the Toughest Conditions</h3>
        <p>With our fabric sourcing expertise, you can be sure that your team’s apparel is crafted from the best fabrics available, designed to withstand the most demanding conditions. Our materials are engineered to handle everything from extreme temperatures and rough terrain to heavy sweat and intense physical activity, all while maintaining their strength, elasticity, and comfort.</p>

        <p>We understand the importance of creating gear that not only looks great but also performs well under pressure. Our fabrics are rigorously tested to ensure they provide the support, comfort, and durability that athletes need to perform at their peak, season after season.</p>

        <h3>Why Choose Our Fabric Sourcing and Supply Service?</h3>
        <ul>
            <li><strong>Premium Selection:</strong> A wide range of high-performance fabrics for every sport and condition.</li>
            <li><strong>Custom Solutions:</strong> Tailored fabric options designed to meet the specific needs of your team and sport.</li>
            <li><strong>Sustainability:</strong> Eco-friendly fabrics that support responsible sourcing and environmental stewardship.</li>
            <li><strong>Quality and Durability:</strong> Fabrics that stand the test of time and rigorous conditions.</li>
            <li><strong>Expert Guidance:</strong> Experienced fabric sourcing professionals to help guide your selection process.</li>
        </ul>

        <p>When you choose our fabric sourcing and supply service, you're not just getting a fabric – you're getting a material that’s designed to help your athletes perform at their best. Let us provide you with the highest-quality fabrics for your custom sportswear and help your team stay comfortable, competitive, and durable on the field or court.</p>
    ",
    ImageUrl = "fabric.png"
},

      new Service
{
    Title = "Garment Stitching",
    short_dsec="We provide precise, durable garment stitching for high-quality sportswear, ensuring strength, comfort, and a perfect fit.",
    Description = @"
        <p>We provide precise, durable garment stitching for high-quality sportswear, ensuring strength, comfort, and a perfect fit. Our garment stitching services are designed to meet the rigorous demands of sports apparel, ensuring that every piece is built to last and withstand constant movement, stretching, and wear. Whether it’s a professional team’s uniform or a school’s sports kit, we take great care in crafting garments that support performance while offering superior durability and comfort.</p>

        <h3>Industrial-Strength Stitching for Durability</h3>
        <p>Sports apparel undergoes intense physical activity and stress, and we understand the importance of garment strength. Our garment stitching services are tailored to meet these demands. We use industrial-strength stitching techniques to reinforce key stress points in the garment, providing added durability in areas that experience the most wear and tear. This includes areas such as the armpits, crotch, and knees, where high flexibility and movement occur.</p>

        <p>By using reinforced stitching in these critical areas, we ensure that the garment holds up under the most strenuous conditions, whether it’s high-intensity training, fast-paced games, or regular practice sessions. This attention to detail results in clothing that lasts longer and performs better, season after season.</p>

        <h3>Perfect Fit and Comfort</h3>
        <p>Perfectly aligned stitching isn’t just about durability—it’s also about achieving the best fit and comfort for athletes. Our expert seamstresses and tailors ensure that every stitch is meticulously placed for optimal comfort and performance. Whether it’s ensuring the perfect fit around the shoulders, waist, or thighs, we understand how important it is for athletes to feel unrestricted in their movement while wearing their gear.</p>

        <p>We also pay close attention to the overall garment design, ensuring that stitching aligns perfectly with the fabric’s stretch and structure. This ensures that there is no discomfort or restriction, allowing athletes to perform their best without worrying about their apparel.</p>

        <h3>State-of-the-Art Machinery for Precision</h3>
        <p>To achieve the highest level of stitching precision, we use state-of-the-art machinery that allows for uniform, consistent stitching across all garments. From straight stitches to complex patterns, our machines are equipped to handle any design with precision. This technology not only ensures that every stitch is perfectly aligned, but also speeds up the production process without sacrificing quality.</p>

        <p>Our machinery is paired with skilled artisans who are experts in the field, ensuring that each piece of sportswear receives the care and attention it deserves. Whether it's a custom design or a standard pattern, our team is committed to delivering top-quality, uniform stitching across all items.</p>

        <h3>Quality Control for Every Garment</h3>
        <p>Every garment we produce undergoes rigorous quality control to ensure it meets our high standards. Our team checks each piece of clothing for precision in stitching, fit, and overall finish. We check for any imperfections or inconsistencies in the stitching, making sure that each garment meets our strict guidelines for durability, comfort, and appearance.</p>

        <p>We’re committed to ensuring that every product sent out meets the expectations of our clients. Our quality control process ensures that every stitch, seam, and edge is perfect, so you can trust that every piece of apparel is ready for performance.</p>

        <h3>Garments Built for High-Performance</h3>
        <p>Our garment stitching services are designed with one goal in mind: to create apparel that supports athletes in every performance, every game, and every practice. We recognize that athletes need gear that can keep up with the physical demands of their sport, and that starts with expertly crafted stitching. Our stitching techniques enhance flexibility, minimize discomfort, and ensure that each garment withstands the roughest conditions.</p>

        <p>Whether you need reinforced stitching for rugby uniforms, flexible and breathable stitching for soccer kits, or durable stitching for training gear, we’ve got you covered. Our garments are built to handle the most demanding sports environments and provide athletes with the comfort and durability they need to excel.</p>

        <h3>Why Choose Our Garment Stitching Service?</h3>
        <ul>
            <li><strong>Durability:</strong> Industrial-strength stitching that stands up to constant wear and tear.</li>
            <li><strong>Comfort:</strong> Precision stitching for an ideal fit that allows maximum mobility.</li>
            <li><strong>High-Quality Standards:</strong> Every garment undergoes strict quality control checks before being sent out.</li>
            <li><strong>State-of-the-Art Equipment:</strong> Advanced stitching machinery for accurate and uniform results.</li>
            <li><strong>Expert Craftsmanship:</strong> Skilled seamstresses and tailors dedicated to delivering perfect stitching every time.</li>
        </ul>

        <p>When you choose our garment stitching services, you're investing in apparel that lasts. We make sure every stitch supports the performance of athletes while providing them with the comfort they need to excel. Let us help you outfit your team with sportswear that delivers in both durability and fit, from the first stitch to the final product.</p>
    ",
    ImageUrl = "sewing-machine.png"
},
       new Service
{
    Title = "Private Label Manufacturing",
    short_dsec="Our private label manufacturing services provide tailored solutions to help bring your brand vision to life with high-quality products crafted to your exact specifications.",
    Description = @"
        <p>Our private label manufacturing services provide tailored solutions to help bring your brand vision to life with high-quality products crafted to your exact specifications. Whether you’re an established brand looking to expand your product line or a startup with a fresh concept, we collaborate closely with you to ensure every aspect of your product aligns with your brand identity. Our goal is to produce not just a product, but a piece of your brand’s story that resonates with your customers and stands out in the market.</p>

        <h3>Complete End-to-End Manufacturing Solutions</h3>
        <p>We understand that creating your own brand can be a complex process, but with our comprehensive private label manufacturing services, we simplify it for you. We take care of every aspect of the manufacturing journey, from initial concept to the finished product. Our experienced team guides you through the entire process, providing clear communication and expert advice along the way to ensure that your vision is realized to the fullest.</p>

        <p>Our end-to-end services include:</p>
        <ul>
            <li><strong>Concept Development:</strong> Work closely with our design team to shape your product ideas into reality.</li>
            <li><strong>Material Sourcing:</strong> We help source high-quality materials that align with your brand and product needs.</li>
            <li><strong>Prototype Creation:</strong> Our experts will craft prototypes so you can see and feel the product before it goes into full production.</li>
            <li><strong>Production & Quality Control:</strong> Once the design is approved, we move into full production, ensuring that every item is crafted to the highest standards with strict quality control.</li>
            <li><strong>Packaging & Branding:</strong> Customize labels, tags, and packaging to perfectly reflect your brand’s identity and message.</li>
        </ul>

        <h3>Collaborative Design and Branding</h3>
        <p>We work with you every step of the way, from the initial design concept to the finished product. Our team is skilled at taking your ideas and translating them into high-quality apparel and accessories that not only meet your specifications but also reflect your brand's unique identity. Whether you're looking to create custom labels, logos, or specialized packaging, we ensure that every detail enhances the recognition and appeal of your brand.</p>

        <p>Our designers will help you bring your ideas to life, suggesting creative ways to incorporate your brand's messaging into every element of the product. Whether you need a simple, sleek look or a bold, eye-catching design, we have the expertise to create products that will make your brand shine.</p>

        <h3>High-Quality Manufacturing Processes</h3>
        <p>We use top-notch manufacturing processes to produce garments that not only look great but also deliver on performance. Our team utilizes the latest technologies and techniques to ensure that every item meets the highest standards of craftsmanship and durability. Whether you’re creating sportswear, athleisure, or fashion accessories, our processes are designed to deliver consistent, high-quality results.</p>

        <p>Our production methods ensure precision in every detail, from the stitching to the fit, so that your products meet the highest standards of both functionality and aesthetics. We use durable, high-performance fabrics, and cutting-edge techniques to produce garments that perform as well as they look. Every item is crafted with attention to detail, ensuring consistency and quality across your product line.</p>

        <h3>Brand-Focused Customization</h3>
        <p>Every brand is unique, and we are committed to making your products stand out with personalized design elements that align with your identity. Our private label services give you full creative control, from custom color schemes to exclusive fabrics and textures, ensuring that your products are distinct and truly representative of your brand’s vision.</p>

        <p>We can help design everything from custom labels, tags, and embellishments to specialty trims and embroidery, ensuring that every detail aligns with your brand’s aesthetic. We also offer specialized packaging options, from boxes to polybags, that make a lasting impression and add to the unboxing experience for your customers.</p>

        <h3>Scalable Solutions for Growing Brands</h3>
        <p>One of the greatest advantages of our private label manufacturing service is its scalability. Whether you are just starting out or already managing an established product line, we can scale production to meet your needs. We offer flexibility that ensures your product line grows with your business, whether you're increasing your order volume or expanding to new product categories.</p>

        <p>From small initial runs for new product concepts to large, ongoing orders as your brand grows, we provide flexible manufacturing solutions that allow you to keep up with demand. As your business grows, we are here to support you every step of the way, adapting our services to meet your evolving needs and ensuring that your products maintain the highest standards of quality and performance.</p>

        <h3>Why Choose Our Private Label Manufacturing Service?</h3>
        <ul>
            <li><strong>Customization:</strong> Fully customizable designs and products to create unique items that perfectly align with your brand's identity.</li>
            <li><strong>Expert Guidance:</strong> Our experienced team collaborates with you to turn your vision into reality, offering support and expertise every step of the way.</li>
            <li><strong>High-Quality Manufacturing:</strong> We use state-of-the-art manufacturing techniques and only the highest-quality materials to ensure your products stand out for both their performance and style.</li>
            <li><strong>Scalable Production:</strong> Whether you’re starting with a small batch or scaling up to large volumes, we have the capacity to meet your growing needs.</li>
            <li><strong>Comprehensive Services:</strong> From concept development to final production, packaging, and branding, we offer a full range of services that cover every aspect of the private label process.</li>
            <li><strong>Consistency:</strong> Our rigorous quality control process ensures that every product meets the same high standards of durability and craftsmanship, regardless of batch size.</li>
        </ul>

        <h3>Bring Your Brand to Life</h3>
        <p>With our private label manufacturing services, you can turn your brand concept into a reality. We provide the expertise, quality, and flexibility to create products that align with your brand’s identity and appeal to your customers. Our team is dedicated to producing garments and accessories that represent your brand at its best, ensuring your products resonate with your target audience and help you build a loyal customer base.</p>

        <p>Whether you’re launching a new product or enhancing your existing collection, our private label services offer the support you need to succeed. Let us help you create the high-quality, custom-branded products your customers will love. Together, we can make your brand a standout success.</p>
    ",
    ImageUrl = "textile (3).png"
},
        new Service
{
    Title = "Custom Apparel",
    short_dsec="We offer custom apparel designed to meet your unique style and performance needs with precision and quality. From custom sports jerseys and fan gear to personalized training equipment and accessories, we provide full-service solutions for all your custom apparel needs.",
    Description = @"
        <p>We offer custom apparel designed to meet your unique style and performance needs with precision and quality. From custom sports jerseys and fan gear to personalized training equipment and accessories, we provide full-service solutions for all your custom apparel needs. Whether you're outfitting a sports team, running a promotional campaign, or organizing an event, our custom apparel services ensure you make a lasting impression.</p>

        <h3>One-of-a-Kind Designs for Every Need</h3>
        <p>Our team of expert designers works closely with you to bring your vision to life. We understand that every organization has its own unique identity and needs, which is why we offer fully customizable solutions that reflect your brand, event, or team's personality. Whether you're looking for custom sports jerseys, personalized fan gear, or branded accessories, we create apparel that not only meets but exceeds your expectations.</p>

        <p>We specialize in creating apparel that blends functionality with style. From professional sports teams looking for high-performance gear to businesses wanting custom uniforms or promotional merchandise, our custom apparel services cater to a wide variety of industries and needs. We ensure that each piece we create is a perfect fit for your requirements, whether you need something durable for athletic performance or stylish for brand promotion.</p>

        <h3>Customization Options to Make Your Apparel Stand Out</h3>
        <p>We offer a wide range of customization options to make your apparel truly unique. Our capabilities include:</p>
        <ul>
            <li><strong>Embroidered Logos and Names:</strong> Add a professional touch with embroidered logos, team names, and individual names on your apparel. Perfect for jerseys, jackets, and accessories.</li>
            <li><strong>Sublimation Printing:</strong> Our full-color sublimation printing allows for intricate and vibrant designs, perfect for high-quality, colorful graphics on uniforms and fan gear.</li>
            <li><strong>Custom Text and Graphics:</strong> Add custom text, graphics, or patterns to your apparel to enhance its personal or brand identity.</li>
            <li><strong>Unique Fabric Choices:</strong> Select the right fabric to match your performance needs, whether it's moisture-wicking fabric for athletic wear, or soft, breathable cotton for fan gear and casual wear.</li>
        </ul>

        <h3>Personalized Sizing for Perfect Fit</h3>
        <p>We understand that comfort and performance go hand in hand, which is why we offer personalized sizing options to ensure that every item fits perfectly. Whether you're outfitting a team or providing custom apparel for your business, we provide a variety of sizing options to accommodate every individual. From youth sizes to adult plus sizes, we ensure that every person gets the best fit, enhancing both comfort and performance.</p>

        <p>Our attention to detail in sizing is crucial for ensuring that athletes have the right gear for peak performance, while fans and employees can enjoy their apparel with confidence, knowing it fits just right. We want you to feel comfortable and perform at your best, so we offer size consultations and samples to help you find the best fit for your custom pieces.</p>

        <h3>Custom Apparel for Every Occasion</h3>
        <p>Whether you're designing apparel for a sports team, a company event, or a marketing campaign, our custom apparel is designed to make a statement. Some of the applications for our custom apparel include:</p>
        <ul>
            <li><strong>Sports Teams:</strong> From jerseys to training wear, we provide durable, high-performance gear that helps your team perform their best while representing their team with pride.</li>
            <li><strong>Business and Corporate Uniforms:</strong> Outfit your employees with custom uniforms that reflect your brand’s professionalism, making your company look great while boosting employee morale.</li>
            <li><strong>Fan Gear:</strong> Show your team spirit or brand loyalty with custom fan apparel, including T-shirts, hats, and scarves that fans will love to wear and show off.</li>
            <li><strong>Promotional Merchandise:</strong> Create eye-catching promotional apparel for giveaways, events, or marketing campaigns, helping you build brand recognition and customer loyalty.</li>
        </ul>

        <h3>Why Choose Our Custom Apparel Service?</h3>
        <ul>
            <li><strong>Endless Customization Options:</strong> From embroidery to sublimation printing, we offer a wide variety of customization options to make your apparel truly unique.</li>
            <li><strong>High-Quality Materials:</strong> We use only the best materials to ensure that your custom apparel is not only stylish but also durable and functional.</li>
            <li><strong>Perfect Fit:</strong> Our personalized sizing options guarantee that every item fits perfectly, providing comfort and enhancing performance.</li>
            <li><strong>Professional Design Team:</strong> Our expert designers work closely with you to ensure that your custom apparel reflects your brand and vision with precision and quality.</li>
            <li><strong>Timely Delivery:</strong> We are committed to delivering high-quality custom apparel on time, no matter how large or small your order is.</li>
        </ul>

        <h3>Make a Statement with Custom Apparel</h3>
        <p>Custom apparel is a powerful way to express individuality, unite teams, and promote your brand. Whether you need custom gear for athletic performance, promotional campaigns, or fan spirit, we offer a full suite of options to ensure your apparel stands out. Our custom apparel services give you the flexibility to create unique products that not only look great but also serve a purpose, whether it’s for athletic performance, team spirit, or brand promotion.</p>

        <p>Let us help you bring your vision to life with high-quality, custom-designed apparel that will leave a lasting impression. Contact us today to start designing your one-of-a-kind pieces!</p>
    ",
    ImageUrl = "textile (2).png"
}
    };
        }
    
        public IActionResult Index()
        {
            // Fetch the latest 3 blogs
            var blogs = _context.tbl_blog.Take(3).ToList();

            // Fetch the top 10 products
            var products = _context.tbl_products.Take(10).ToList();

            // Fetch the Services
            var services = GetServices();

            // Create the view model
            var viewModel = new CombineViewModel
            {
                Service = services,
                tbl_blog = blogs,
                tbl_products = products
            };

            return View(viewModel);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Services()
        {
            var services = GetServices();
            return View(services);
        }

        public IActionResult ServiceDetail(string title)
        {
            var services = GetServices();
            var service = services.FirstOrDefault(s => s.Title == title);

            if (service == null)
            {
                // Return a custom view or NotFound page if the service is not found
                return View("ServiceNotFound"); // or return NotFound();
            }

            return View(service); // Pass the service details to the view
        }

        public IActionResult Director()
        {
            return View();
        }

        public IActionResult Products()
        {
            var data = _context.tbl_products.ToList();
            return View(data);
        }

        public IActionResult ProductDetails(int id)
        {
            var data = _context.tbl_products.Find(id);
            return View(data);
        }

        public IActionResult Clients()
        {
            return View();
        }
        public IActionResult Blog()
        {
            var data = _context.tbl_blog.ToList();
            return View(data);
        }

        [Route("Home/BlogDetail/{title}")]
        public IActionResult BlogDetail(string title)
        {
            // Ensure the title matches what was passed in the URL
            string formattedTitle = title.Replace('-', ' ');  // Convert hyphens back to spaces

            // Fetch the specific blog based on the formatted title
            var data = _context.tbl_blog.FirstOrDefault(b => b.title == formattedTitle);

            // Handle the case where no blog is found
            if (data == null)
            {
                // Optionally, redirect to an error page or return a 404
                return NotFound();  // Or you can return a custom error page
            }

            // Fetch the most recent blogs (e.g., 8 most recent blogs)
            var recentBlogs = _context.tbl_blog
                                      .OrderByDescending(b => b.date) // Assuming 'created_date' is your date field
                                      .Take(8) // Limit to top 8 recent blogs
                                      .ToList();

            // Create a CombineViewModel and populate it
            var model = new CombineViewModel
            {
                tbl_blog = recentBlogs // Assign recent blogs to tbl_blog list
            };

            // Pass the specific blog to the view using ViewBag
            ViewBag.Blog = data;

            return View(model); // Return the view with the combined data
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }
        public IActionResult Career()
        {
            return View();
        }

        // POST: CareerForm
        [HttpPost]
        public async Task<IActionResult> CareerForm(tbl_career model, IFormFile resume, IFormFile coverLetter)
        {
            // Handle file upload (for resume and cover letter)
            var resumeFilePath = await SaveFileAsync(resume);
            var coverLetterFilePath = coverLetter != null ? await SaveFileAsync(coverLetter) : null;

            // Save career data in the database
            model.resume = resumeFilePath;
            model.coverLetter = coverLetterFilePath;

            _context.tbl_career.Add(model);
            await _context.SaveChangesAsync();

            // Send email to admin
            string adminEmail = "puri.saisports@gmail.com"; // Replace with admin email address
            string subject = "New Career Application";

            string body = $@"
    <html>
    <body>
        <h2>New Career Application Submitted</h2>
        <table border='1' cellpadding='5'>
            <tr>
                <td><strong>Full Name</strong></td>
                <td>{model.fullName}</td>
            </tr>
            <tr>
                <td><strong>Email</strong></td>
                <td>{model.email}</td>
            </tr>
            <tr>
                <td><strong>Phone Number</strong></td>
                <td>{model.phone}</td>
            </tr>
            <tr>
                <td><strong>Resume</strong></td>
                <td><a href='{model.resume}' target='_blank'>Click to View Resume</a></td>
            </tr>
            <tr>
                <td><strong>Cover Letter</strong></td>
                <td><a href='{model.coverLetter}' target='_blank'>Click to View Cover Letter</a></td>
            </tr>
        </table>
    </body>
    </html>";

            await _emailSender.SendEmailAsync(adminEmail, subject, body);

            TempData["Message"] = $"Your Form Submitted Successfully!";

            return RedirectToAction("Career", "Home"); // Redirect to a thank you page
        }

        // Utility method to save file
        private async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            // Generate a unique file name using GUID and preserve the file extension
            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

            // Define the file path to save the file
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", uniqueFileName);

            // Save the file to the server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Return the file path relative to the root directory for saving in the database
            return "/uploads/" + uniqueFileName;
        }

        [HttpPost]
        public async Task<IActionResult> EnquiryForm(tbl_enquiries e)
        {
            // 1. Get reCAPTCHA response from form
            var recaptchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LdVSmYrAAAAAPqyfCAqHlRhwfjZoPJO_bnpHahW"; // Replace with your secret key

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
        {
            { "secret", secretKey },
            { "response", recaptchaResponse }
        };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                var result = await response.Content.ReadAsStringAsync();

                var captchaResult = JsonSerializer.Deserialize<RecaptchaResponse>(result);

                if (!captchaResult.success)
                {
                    TempData["error"] = "reCAPTCHA verification failed. Please try again.";
                    return RedirectToAction("ContactUs");
                }
            }

            // Add the enquiry to the database
            _context.tbl_enquiries.Add(e);
            _context.SaveChanges();

            // Compose the email content after saving the form
            string subject = $"New Form Submission from {e.name} - Sai Sports India";
            string body = $@"
<div style='font-family: Arial, sans-serif; color: #333; line-height: 1.6;'>
    <h2 style='color: #007BFF;'>Sai Sports India, Lucknow</h2>
    <p>Dear Team,</p>
    <p>You have received a new Contact Form submission. Here are the details:</p>
    <table style='border-collapse: collapse; width: 100%;'>
        <tr><td style='border: 1px solid #ddd; padding: 8px; font-weight: bold;'>Subject</td><td style='border: 1px solid #ddd; padding: 8px;'>{e.subject}</td></tr>
        <tr><td style='border: 1px solid #ddd; padding: 8px; font-weight: bold;'>Name</td><td style='border: 1px solid #ddd; padding: 8px;'>{e.name}</td></tr>
        <tr><td style='border: 1px solid #ddd; padding: 8px; font-weight: bold;'>Phone</td><td style='border: 1px solid #ddd; padding: 8px;'>{e.phone}</td></tr>
        <tr><td style='border: 1px solid #ddd; padding: 8px; font-weight: bold;'>Email</td><td style='border: 1px solid #ddd; padding: 8px;'>{e.email}</td></tr>
        <tr><td style='border: 1px solid #ddd; padding: 8px; font-weight: bold;'>Message</td><td style='border: 1px solid #ddd; padding: 8px;'>{e.msg}</td></tr>
    </table>
    <p style='margin-top: 20px;'>Best Regards,<br/>Sai Sports India, Lucknow<br/><a href='mailto:support@saisportsindia.com'>support@saisportsindia.com</a></p>
</div>";

            // Send the email
            _emailSender.SendEmailAsync("puri.saisports@gmail.com", subject, body);

            TempData["message"] = "Your form was submitted successfully!";
            return RedirectToAction("ContactUs");
        }

        public class RecaptchaResponse
        {
            public bool success { get; set; }

            public DateTime challenge_ts { get; set; }

            public string hostname { get; set; }

            [JsonPropertyName("error-codes")]
            public List<string> error_codes { get; set; }
        }


        public IActionResult SSAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var data = _context.tbl_admin.FirstOrDefault(e => e.userid == email && e.password == password);
            if (data != null)
            {
                HttpContext.Session.SetString("admin", email);
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                TempData["msg"] = "Email & Password is Incorrect.";
                return RedirectToAction("SSAdmin", "Home");

            }
        }
    }
}
